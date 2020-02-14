using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Game.Glfw
{
    public static partial class GL
    {
        public const int ARRAY_BUFFER = 0x8892;
        public const int ELEMENT_ARRAY_BUFFER = 0x8893;
        public const int STATIC_DRAW = 0x88E4;
        public const uint UNSIGNED_INT = 0x1405;
        public const int FLOAT = 0x1406;

        public const int TRIANGLES = 0x0004;
        public const int COLOR_BUFFER_BIT = 0x4000;

        public const uint VENDOR = 0x1F00;
        public const uint RENDERER = 0x1F01;
        public const uint VERSION = 0x1F02;
        public const uint EXTENSIONS = 0x1F03;
        public const uint SHADING_LANGUAGE_VERSION = 0x18B8C;

        public const uint FRAGMENT_SHADER = 0x8B30;
        public const uint VERTEX_SHADER = 0x8B31;
        public const uint GEOMETRY_SHADER = 0x8DD9;
        public const uint TEST_CONTROL_SHADER = 0x8E88;
        public const uint TEST_EVALUATION_SHADER = 0x8E87;
        public const uint COMPUTE_SHADER = 0x91B9;

        public const uint ACTIVE_UNIFORM_BLOCK_MAX_NAME_LENGTH = 0x8A35;
        public const uint ACTIVE_UNIFORM_BLOCKS = 0x8A36;
        public const uint DELETE_STATUS = 0x8B80;
        public const uint LINK_STATUS = 0x8B82;
        public const uint VALIDATE_STATUS = 0x8B83;
        public const uint INFO_LOG_LENGTH = 0x8B84;
        public const uint ATTACHED_SHADERS = 0x8B85;
        public const uint ACTIVE_UNIFORMS = 0x8B86;
        public const uint ACTIVE_UNIFORM_MAX_LENGTH = 0x8B87;
        public const uint ACTIVE_ATTRIBUTES = 0x8B89;
        public const uint ACTIVE_ATTRIBUTE_MAX_LENGTH = 0x8B8A;
        public const uint TRANSFORM_FEEDBACK_VARYING_MAX_LENGTH = 0x8C76;
        public const uint TRANSFORM_FEEDBACK_BUFFER_MODE = 0x8C7F;
        public const uint TRANSFORM_FEEDBACK_VARYINGS = 0x8C83;
        public const uint GEOMETRY_VERTICES_OUT = 0x8DDA;
        public const uint GEOMETRY_INPUT_TYPE = 0x8DDB;
        public const uint GEOMETRY_OUTPUT_TYPE = 0x8DDC;

        public const uint GL_CURRENT_COLOR                  = 0x0B00;
		public const uint GL_CURRENT_INDEX                  = 0x0B01;
		public const uint GL_CURRENT_NORMAL                 = 0x0B02;
		public const uint GL_CURRENT_TEXTURE_COORDS         = 0x0B03;
		public const uint GL_CURRENT_RASTER_COLOR           = 0x0B04;
		public const uint GL_CURRENT_RASTER_INDEX           = 0x0B05;
		public const uint GL_CURRENT_RASTER_TEXTURE_COORDS  = 0x0B06;
		public const uint GL_CURRENT_RASTER_POSITION        = 0x0B07;
		public const uint GL_CURRENT_RASTER_POSITION_VALID  = 0x0B08;
		public const uint GL_CURRENT_RASTER_DISTANCE        = 0x0B09;
		public const uint GL_POINT_SMOOTH                   = 0x0B10;
		public const uint GL_POINT_SIZE                     = 0x0B11;
		public const uint GL_POINT_SIZE_RANGE               = 0x0B12;
		public const uint GL_POINT_SIZE_GRANULARITY         = 0x0B13;
		public const uint GL_LINE_SMOOTH                    = 0x0B20;
		public const uint GL_LINE_WIDTH                     = 0x0B21;
		public const uint GL_LINE_WIDTH_RANGE               = 0x0B22;
		public const uint GL_LINE_WIDTH_GRANULARITY         = 0x0B23;
		public const uint GL_LINE_STIPPLE                   = 0x0B24;
		public const uint GL_LINE_STIPPLE_PATTERN           = 0x0B25;
		public const uint GL_LINE_STIPPLE_REPEAT            = 0x0B26;
		public const uint GL_LIST_MODE                      = 0x0B30;
		public const uint GL_MAX_LIST_NESTING               = 0x0B31;
		public const uint GL_LIST_BASE                      = 0x0B32;
		public const uint GL_LIST_INDEX                     = 0x0B33;
		public const uint GL_POLYGON_MODE                   = 0x0B40;
		public const uint GL_POLYGON_SMOOTH                 = 0x0B41;
		public const uint GL_POLYGON_STIPPLE                = 0x0B42;
		public const uint GL_EDGE_FLAG                      = 0x0B43;
		public const uint GL_CULL_FACE                      = 0x0B44;
		public const uint GL_CULL_FACE_MODE                 = 0x0B45;
		public const uint GL_FRONT_FACE                     = 0x0B46;
		public const uint GL_LIGHTING                       = 0x0B50;
		public const uint GL_LIGHT_MODEL_LOCAL_VIEWER       = 0x0B51;
		public const uint GL_LIGHT_MODEL_TWO_SIDE           = 0x0B52;
		public const uint GL_LIGHT_MODEL_AMBIENT            = 0x0B53;
		public const uint GL_SHADE_MODEL                    = 0x0B54;
		public const uint GL_COLOR_MATERIAL_FACE            = 0x0B55;
		public const uint GL_COLOR_MATERIAL_PARAMETER       = 0x0B56;
		public const uint GL_COLOR_MATERIAL                 = 0x0B57;
		public const uint GL_FOG                            = 0x0B60;
		public const uint GL_FOG_INDEX                      = 0x0B61;
		public const uint GL_FOG_DENSITY                    = 0x0B62;
		public const uint GL_FOG_START                      = 0x0B63;
		public const uint GL_FOG_END                        = 0x0B64;
		public const uint GL_FOG_MODE                       = 0x0B65;
		public const uint GL_FOG_COLOR                      = 0x0B66;
		public const uint GL_DEPTH_RANGE                    = 0x0B70;
		public const uint GL_DEPTH_TEST                     = 0x0B71;
		public const uint GL_DEPTH_WRITEMASK                = 0x0B72;
		public const uint GL_DEPTH_CLEAR_VALUE              = 0x0B73;
		public const uint GL_DEPTH_FUNC                     = 0x0B74;
		public const uint GL_ACCUM_CLEAR_VALUE              = 0x0B80;
		public const uint GL_STENCIL_TEST                   = 0x0B90;
		public const uint GL_STENCIL_CLEAR_VALUE            = 0x0B91;
		public const uint GL_STENCIL_FUNC                   = 0x0B92;
		public const uint GL_STENCIL_VALUE_MASK             = 0x0B93;
		public const uint GL_STENCIL_FAIL                   = 0x0B94;
		public const uint GL_STENCIL_PASS_DEPTH_FAIL        = 0x0B95;
		public const uint GL_STENCIL_PASS_DEPTH_PASS        = 0x0B96;
		public const uint GL_STENCIL_REF                    = 0x0B97;
		public const uint GL_STENCIL_WRITEMASK              = 0x0B98;
		public const uint GL_MATRIX_MODE                    = 0x0BA0;
		public const uint GL_NORMALIZE                      = 0x0BA1;
		public const uint GL_VIEWPORT                       = 0x0BA2;
		public const uint GL_MODELVIEW_STACK_DEPTH          = 0x0BA3;
		public const uint GL_PROJECTION_STACK_DEPTH         = 0x0BA4;
		public const uint GL_TEXTURE_STACK_DEPTH            = 0x0BA5;
		public const uint GL_MODELVIEW_MATRIX               = 0x0BA6;
		public const uint GL_PROJECTION_MATRIX              = 0x0BA7;
		public const uint GL_TEXTURE_MATRIX                 = 0x0BA8;
		public const uint GL_ATTRIB_STACK_DEPTH             = 0x0BB0;
		public const uint GL_CLIENT_ATTRIB_STACK_DEPTH      = 0x0BB1;
		public const uint GL_ALPHA_TEST                     = 0x0BC0;
		public const uint GL_ALPHA_TEST_FUNC                = 0x0BC1;
		public const uint GL_ALPHA_TEST_REF                 = 0x0BC2;
		public const uint GL_DITHER                         = 0x0BD0;
		public const uint GL_BLEND_DST                      = 0x0BE0;
		public const uint GL_BLEND_SRC                      = 0x0BE1;
		public const uint GL_BLEND                          = 0x0BE2;
		public const uint GL_LOGIC_OP_MODE                  = 0x0BF0;
		public const uint GL_INDEX_LOGIC_OP                 = 0x0BF1;
		public const uint GL_COLOR_LOGIC_OP                 = 0x0BF2;
		public const uint GL_AUX_BUFFERS                    = 0x0C00;
		public const uint GL_DRAW_BUFFER                    = 0x0C01;
		public const uint GL_READ_BUFFER                    = 0x0C02;
		public const uint GL_SCISSOR_BOX                    = 0x0C10;
		public const uint GL_SCISSOR_TEST                   = 0x0C11;
		public const uint GL_INDEX_CLEAR_VALUE              = 0x0C20;
		public const uint GL_INDEX_WRITEMASK                = 0x0C21;
		public const uint GL_COLOR_CLEAR_VALUE              = 0x0C22;
		public const uint GL_COLOR_WRITEMASK                = 0x0C23;
		public const uint GL_INDEX_MODE                     = 0x0C30;
		public const uint GL_RGBA_MODE                      = 0x0C31;
		public const uint GL_DOUBLEBUFFER                   = 0x0C32;
		public const uint GL_STEREO                         = 0x0C33;
		public const uint GL_RENDER_MODE                    = 0x0C40;
		public const uint GL_PERSPECTIVE_CORRECTION_HINT    = 0x0C50;
		public const uint GL_POINT_SMOOTH_HINT              = 0x0C51;
		public const uint GL_LINE_SMOOTH_HINT               = 0x0C52;
		public const uint GL_POLYGON_SMOOTH_HINT            = 0x0C53;
		public const uint GL_FOG_HINT                       = 0x0C54;
		public const uint GL_TEXTURE_GEN_S                  = 0x0C60;
		public const uint GL_TEXTURE_GEN_T                  = 0x0C61;
		public const uint GL_TEXTURE_GEN_R                  = 0x0C62;
		public const uint GL_TEXTURE_GEN_Q                  = 0x0C63;
		public const uint GL_PIXEL_MAP_I_TO_I               = 0x0C70;
		public const uint GL_PIXEL_MAP_S_TO_S               = 0x0C71;
		public const uint GL_PIXEL_MAP_I_TO_R               = 0x0C72;
		public const uint GL_PIXEL_MAP_I_TO_G               = 0x0C73;
		public const uint GL_PIXEL_MAP_I_TO_B               = 0x0C74;
		public const uint GL_PIXEL_MAP_I_TO_A               = 0x0C75;
		public const uint GL_PIXEL_MAP_R_TO_R               = 0x0C76;
		public const uint GL_PIXEL_MAP_G_TO_G               = 0x0C77;
		public const uint GL_PIXEL_MAP_B_TO_B               = 0x0C78;
		public const uint GL_PIXEL_MAP_A_TO_A               = 0x0C79;
		public const uint GL_PIXEL_MAP_I_TO_I_SIZE          = 0x0CB0;
		public const uint GL_PIXEL_MAP_S_TO_S_SIZE          = 0x0CB1;
		public const uint GL_PIXEL_MAP_I_TO_R_SIZE          = 0x0CB2;
		public const uint GL_PIXEL_MAP_I_TO_G_SIZE          = 0x0CB3;
		public const uint GL_PIXEL_MAP_I_TO_B_SIZE          = 0x0CB4;
		public const uint GL_PIXEL_MAP_I_TO_A_SIZE          = 0x0CB5;
		public const uint GL_PIXEL_MAP_R_TO_R_SIZE          = 0x0CB6;
		public const uint GL_PIXEL_MAP_G_TO_G_SIZE          = 0x0CB7;
		public const uint GL_PIXEL_MAP_B_TO_B_SIZE          = 0x0CB8;
		public const uint GL_PIXEL_MAP_A_TO_A_SIZE          = 0x0CB9;
		public const uint GL_UNPACK_SWAP_BYTES              = 0x0CF0;
		public const uint GL_UNPACK_LSB_FIRST               = 0x0CF1;
		public const uint GL_UNPACK_ROW_LENGTH              = 0x0CF2;
		public const uint GL_UNPACK_SKIP_ROWS               = 0x0CF3;
		public const uint GL_UNPACK_SKIP_PIXELS             = 0x0CF4;
		public const uint GL_UNPACK_ALIGNMENT               = 0x0CF5;
		public const uint GL_PACK_SWAP_BYTES                = 0x0D00;
		public const uint GL_PACK_LSB_FIRST                 = 0x0D01;
		public const uint GL_PACK_ROW_LENGTH                = 0x0D02;
		public const uint GL_PACK_SKIP_ROWS                 = 0x0D03;
		public const uint GL_PACK_SKIP_PIXELS               = 0x0D04;
		public const uint GL_PACK_ALIGNMENT                 = 0x0D05;
		public const uint GL_MAP_COLOR                      = 0x0D10;
		public const uint GL_MAP_STENCIL                    = 0x0D11;
		public const uint GL_INDEX_SHIFT                    = 0x0D12;
		public const uint GL_INDEX_OFFSET                   = 0x0D13;
		public const uint GL_RED_SCALE                      = 0x0D14;
		public const uint GL_RED_BIAS                       = 0x0D15;
		public const uint GL_ZOOM_X                         = 0x0D16;
		public const uint GL_ZOOM_Y                         = 0x0D17;
		public const uint GL_GREEN_SCALE                    = 0x0D18;
		public const uint GL_GREEN_BIAS                     = 0x0D19;
		public const uint GL_BLUE_SCALE                     = 0x0D1A;
		public const uint GL_BLUE_BIAS                      = 0x0D1B;
		public const uint GL_ALPHA_SCALE                    = 0x0D1C;
		public const uint GL_ALPHA_BIAS                     = 0x0D1D;
		public const uint GL_DEPTH_SCALE                    = 0x0D1E;
		public const uint GL_DEPTH_BIAS                     = 0x0D1F;
		public const uint GL_MAX_EVAL_ORDER                 = 0x0D30;
		public const uint GL_MAX_LIGHTS                     = 0x0D31;
		public const uint GL_MAX_CLIP_PLANES                = 0x0D32;
		public const uint GL_MAX_TEXTURE_SIZE               = 0x0D33;
		public const uint GL_MAX_PIXEL_MAP_TABLE            = 0x0D34;
		public const uint GL_MAX_ATTRIB_STACK_DEPTH         = 0x0D35;
		public const uint GL_MAX_MODELVIEW_STACK_DEPTH      = 0x0D36;
		public const uint GL_MAX_NAME_STACK_DEPTH           = 0x0D37;
		public const uint GL_MAX_PROJECTION_STACK_DEPTH     = 0x0D38;
		public const uint GL_MAX_TEXTURE_STACK_DEPTH        = 0x0D39;
		public const uint GL_MAX_VIEWPORT_DIMS              = 0x0D3A;
		public const uint GL_MAX_CLIENT_ATTRIB_STACK_DEPTH  = 0x0D3B;
		public const uint GL_SUBPIXEL_BITS                  = 0x0D50;
		public const uint GL_INDEX_BITS                     = 0x0D51;
		public const uint GL_RED_BITS                       = 0x0D52;
		public const uint GL_GREEN_BITS                     = 0x0D53;
		public const uint GL_BLUE_BITS                      = 0x0D54;
		public const uint GL_ALPHA_BITS                     = 0x0D55;
		public const uint GL_DEPTH_BITS                     = 0x0D56;
		public const uint GL_STENCIL_BITS                   = 0x0D57;
		public const uint GL_ACCUM_RED_BITS                 = 0x0D58;
		public const uint GL_ACCUM_GREEN_BITS               = 0x0D59;
		public const uint GL_ACCUM_BLUE_BITS                = 0x0D5A;
		public const uint GL_ACCUM_ALPHA_BITS               = 0x0D5B;
		public const uint GL_NAME_STACK_DEPTH               = 0x0D70;
		public const uint GL_AUTO_NORMAL                    = 0x0D80;
		public const uint GL_MAP1_COLOR_4                   = 0x0D90;
		public const uint GL_MAP1_INDEX                     = 0x0D91;
		public const uint GL_MAP1_NORMAL                    = 0x0D92;
		public const uint GL_MAP1_TEXTURE_COORD_1           = 0x0D93;
		public const uint GL_MAP1_TEXTURE_COORD_2           = 0x0D94;
		public const uint GL_MAP1_TEXTURE_COORD_3           = 0x0D95;
		public const uint GL_MAP1_TEXTURE_COORD_4           = 0x0D96;
		public const uint GL_MAP1_VERTEX_3                  = 0x0D97;
		public const uint GL_MAP1_VERTEX_4                  = 0x0D98;
		public const uint GL_MAP2_COLOR_4                   = 0x0DB0;
		public const uint GL_MAP2_INDEX                     = 0x0DB1;
		public const uint GL_MAP2_NORMAL                    = 0x0DB2;
		public const uint GL_MAP2_TEXTURE_COORD_1           = 0x0DB3;
		public const uint GL_MAP2_TEXTURE_COORD_2           = 0x0DB4;
		public const uint GL_MAP2_TEXTURE_COORD_3           = 0x0DB5;
		public const uint GL_MAP2_TEXTURE_COORD_4           = 0x0DB6;
		public const uint GL_MAP2_VERTEX_3                  = 0x0DB7;
		public const uint GL_MAP2_VERTEX_4                  = 0x0DB8;
		public const uint GL_MAP1_GRID_DOMAIN               = 0x0DD0;
		public const uint GL_MAP1_GRID_SEGMENTS             = 0x0DD1;
		public const uint GL_MAP2_GRID_DOMAIN               = 0x0DD2;
		public const uint GL_MAP2_GRID_SEGMENTS             = 0x0DD3;
		public const uint GL_TEXTURE_1D                     = 0x0DE0;
		public const uint GL_TEXTURE_2D                     = 0x0DE1;
		public const uint GL_FEEDBACK_BUFFER_POINTER        = 0x0DF0;
		public const uint GL_FEEDBACK_BUFFER_SIZE           = 0x0DF1;
		public const uint GL_FEEDBACK_BUFFER_TYPE           = 0x0DF2;
		public const uint GL_SELECTION_BUFFER_POINTER       = 0x0DF3;
		public const uint GL_SELECTION_BUFFER_SIZE          = 0x0DF4;

        public const uint COMPILE_STATUS = 0x8B81;

        private const string OPENGL_DLL = "opengl32";

        [DllImport(OPENGL_DLL, EntryPoint = "glDrawArrays")]
        public static extern void DrawArrays(uint mode, int first, int count);

        public delegate void glDrawArrays(uint mode, int first, int count);

        public delegate void glAttachShader(uint program, uint shader);

        public delegate void glCreateBuffers(int n, uint[] buffers);

        public delegate void glDeleteBuffers(int n, uint[] buffers);

        public delegate void glGenBuffers(int n, uint[] buffers);

        public delegate void glBindBuffer(uint target, uint buffer);

        public delegate void glBufferData(uint target, int size, IntPtr data, uint usage);

        public delegate uint glCreateProgram();

        public delegate void glDeleteProgram(uint program);

        public delegate void glCreateProgramPipelines(int n, uint[] pipelines);

        public delegate void glEnableVertexAttribArray(uint index);

        public delegate void glVertexAttribPointer(uint indx, int size, uint type, bool normalized, int stride, IntPtr ptr);

        public delegate void glVertexAttribPointerARB(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer);

        public delegate void glGenVertexArrays(int n, uint[] arrays);

        public delegate void glDeleteVertexArrays(int n, uint[] arrays);

        public delegate void glBindVertexArray(uint array);

        public delegate void glClearColor(float r, float g, float b, float a);

        public delegate void glClear(int mask);

        public delegate sbyte glGetString(uint name);

        public delegate void glGetIntegerv(uint pname, int[] parameters);

        public delegate void glDrawElements(int mode, int count, uint type, IntPtr indices);

        public delegate uint glCreateShader(uint type);

        public delegate void glShaderSource(uint shader, int count, string[] _strings, int[] length);

        public delegate void glCompileShader(uint shader);

        public delegate void glGetShaderiv(uint shader, uint pname, int[] _params);

        public delegate void glGetShaderInfoLog(uint shader, int maxLength, IntPtr length, StringBuilder infoLog);

        public delegate void glDeleteShader(uint shader);

        public delegate void glUniformMatrix4fv(int location, int count, bool transpose, float[] value);

        public delegate int glGetUniformLocation(uint program, string name);

        public delegate void glLinkProgram(uint program);

        public delegate void glGetProgramiv(uint program, uint pname, int[] _params);

        public delegate void glGetProgramInfoLog(uint program, int maxLength, IntPtr length, StringBuilder infoLog);

        public delegate void glUseProgram(uint program);

        public delegate void glDetachShader(uint program, uint shader);

        public delegate void glUniform4f(int location, float v0, float v1, float v2, float v3);

        public delegate void glUniform4fv(int location, int count, float[] values);

        public delegate void glTexImage2D(uint target, int level, uint internalformat, int width, int height, int border, uint format, uint type, byte[] pixels);
    }
}